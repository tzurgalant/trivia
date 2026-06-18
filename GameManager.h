#pragma once

#include "Game.h"
#include "Room.h"
#include "IDatabase.h"

class GameManager
{
public:
	GameManager() = default;
	
	GameManager(IDatabase* database) : m_database(database) {};

	Game& createGame(Room room);
	bool deleteGame(int gameId);
	void submitGameStatsToDB(int gameId);
private:
	IDatabase* m_database;
	std::vector<Game> m_games;
};

