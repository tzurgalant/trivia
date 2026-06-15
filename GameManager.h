#pragma once

#include "Game.h"
#include "Room.h"
#include "IDatabase.h"

class GameManager
{
public:
	Game createGame(Room room);
	bool deleteGame(int gameId);
private:
	IDatabase* m_database;
	std::vector<Game> m_games;
};

