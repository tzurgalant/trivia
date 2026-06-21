#include "GameManager.h"

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
    for (auto& game : m_games) 
    {
        if (game.getGameID() == gameId)
        {
            gamePtr = &game;
            break;
        }
    }
    if (gamePtr) {
        auto& players = gamePtr->getPlayers(); 
        for (auto& player : players)
        {
            std::string playerName = player.first.getUserName();
            m_database->submitGameStatsToDB(playerName, player.second);
        }
    }
    
}
Game& GameManager::getGame(int id)
{
    for (auto& game : m_games)
    {

        if (game.getGameID() == id)
        {
            return game; 
        }
    }

    throw std::runtime_error("Game with ID " + std::to_string(id) + " not found!");
}