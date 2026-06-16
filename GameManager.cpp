#include "GameManager.h"


Game& GameManager::createGame(Room room)
{ 
	std::map<LoggedUser, GameData>players;
	std::vector<LoggedUser> users = room.getAllUsers();
	std::list<Question> qL = m_database->getQuestions(10);// question for game

	for (auto lUser : users)
	{
		GameData data = {*qL.begin(),0,0,0};

		players[lUser] = data;
	}
	std::vector<Question> QuestionVector(qL.begin(), qL.end());
	Game game = Game(QuestionVector, players);
	m_games.push_back(game);
	return game;

}
bool GameManager::deleteGame(int gameId)
{

}
void GameManager::submitGameStatsToDB(GameData)
{

}