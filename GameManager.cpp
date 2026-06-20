#include "GameManager.h"

Game& GameManager::createGame(Room room)
{ 
	std::map<LoggedUser, GameData>players;
	std::vector<LoggedUser> users = room.getAllUsers();
	std::list<Question> qL = m_database->getQuestions(room.getRoomData().numOfQuestionsInGame);// question for game
    if (qL.size() == 0)
    {
        throw std::exception("not habe questions on database!!");
    }
	for (auto lUser : users)
	{
		GameData data = {*qL.begin(),0,0,0};

		players[lUser] = data;
	}
	std::vector<Question> QuestionVector(qL.begin(), qL.end());
	Game game = Game(room.getRoomData().id, QuestionVector, players);
    m_games.emplace_back(room.getRoomData().id, QuestionVector, players);
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
    Game gameW;
    std::string playerName;
    for (auto game : m_games)
    {
        if (game.getGameID() == gameId)
        {
            gameW = game;
            break;
        }
    }
    std::map<LoggedUser, GameData> players = gameW.getPlayers();
    for (auto player : players )
    {   
        playerName = player.first.getUserName();
        m_database->submitGameStatsToDB(playerName, player.second);
    }
}

