#pragma once

#include "Game.h"
#include "Room.h"
#include "IDatabase.h"
#include <thread>
#include <mutex>
#include <atomic>
class GameManager
{
public:
	GameManager() = default;
	
	GameManager(IDatabase* database);
	~GameManager();
	Game& createGame(Room room);
	bool deleteGame(int gameId);
	void submitGameStatsToDB(int gameId);
	Game& getGame(int id);
private:
	IDatabase* m_database;
	std::vector<Game> m_games;

	//for the sumbit on the db on the new thread
	std::thread m_monitorThread;
	std::atomic<bool> m_running{ true };
	std::mutex m_gamesMutex;

	void monitorGamesLoop();
};

