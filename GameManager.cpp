#include "GameManager.h"


GameManager::GameManager(IDatabase* db) : m_database(db), m_running(true)
{
    m_monitorThread = std::thread(&GameManager::monitorGamesLoop, this);
}

GameManager::~GameManager()
{
    m_running = false; 
    if (m_monitorThread.joinable())
    {
        m_monitorThread.join(); 
    }
}
void GameManager::monitorGamesLoop()
{
    while (m_running)
    {
        std::this_thread::sleep_for(std::chrono::seconds(1));

        if (!m_running) break;

        std::lock_guard<std::mutex> lock(m_gamesMutex);

        auto it = m_games.begin();
        while (it != m_games.end())
        {
            if (it->isGameStop()&& !it->isSubmitted())
            {
                int finishedGameId = it->getGameID();

                std::cout << "[Monitor] Game ID " << finishedGameId << " has finished. Submitting Stats..." << std::endl;

                // Safe to call now because we already hold the m_gamesMutex lock!
                submitGameStatsToDB(finishedGameId);
                it->setSubmitted(true);
            }
            ++it;
        }   
        it = m_games.begin();
        while (it != m_games.end())
        {
            if (it->getPlayers().empty())
            {
                int finishedGameId = it->getGameID();
                std::cout << "[Monitor] Game ID " << finishedGameId << " is empty. Closing game..." << std::endl;
                it = m_games.erase(it);
                continue;
            }
            ++it;
        }
    }
}
Game& GameManager::createGame(Room room)
{
    std::map<LoggedUser, GameData> players;
    std::vector<LoggedUser> users = room.getAllUsers();

    std::list<Question> qL = m_database->getQuestions(room.getRoomData().numOfQuestionsInGame);

    if (qL.empty()) 
    {
        throw std::runtime_error("No questions found in the database!!");
    }

    for (const auto& lUser : users)
    {
        GameData data = { *qL.begin(), 0, 0, 0 };
        players[lUser] = data;
    }

    std::vector<Question> questionVector(qL.begin(), qL.end());
    std::lock_guard<std::mutex> lock(m_gamesMutex);
    m_games.emplace_back(room.getRoomData().id, questionVector, players);

    return m_games.back();
}

bool GameManager::deleteGame(int gameId)
{
    auto it = m_games.begin();
    while (it != m_games.end())
    {
        if (it->getGameID() == gameId)
        {
            it = m_games.erase(it);
            return true;
        }
        else
        {
            ++it; 
        }
    }
    return false;
}
void GameManager::submitGameStatsToDB(int gameId)
{
    Game* gamePtr = nullptr;

    // Find the correct game session safely
    for (auto& game : m_games)
    {
        if (game.getGameID() == gameId)
        {
            gamePtr = &game;
            break;
        }
    }

    // If the game was found, update everyone's statistics
    if (gamePtr)
    {
        auto& players = gamePtr->getPlayers();
        for (auto& player : players)
        {
            std::string playerName = player.first.getUserName();
            GameData& stats = player.second;

            // Submit to the SQLite database handler
            m_database->submitGameStatsToDB(playerName, stats);
        }
    }
}
Game& GameManager::getGame(int id)
{
    std::lock_guard<std::mutex> lock(m_gamesMutex);
    for (auto& game : m_games)
    {

        if (game.getGameID() == id)
        {
            return game; 
        }
    }
    throw std::runtime_error("Game with ID " + std::to_string(id) + " not found!");
}