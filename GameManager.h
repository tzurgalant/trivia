#pragma once

#include "Game.h"
#include "Room.h"
#include "IDatabase.h"

class GameManager
{
public:
	GameManager() = default;
	Game& createGame(Room room);
	bool deleteGame(int gameId);
	void submitGameStatsToDB(GameData);
private:
	IDatabase* m_database;
	std::vector<Game> m_games;
};

