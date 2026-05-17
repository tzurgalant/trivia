#pragma once

#include "IDatabase.h"
#include <iostream>
#include <string>
#include <vector>

class StatisticsManager
{
	public:
	StatisticsManager(IDatabase* database) : m_database(database) {};
	~StatisticsManager() {};

	std::vector<std::string> getHighScore();
	std::vector<std::string> getUserStatistics(std::string username);

private:
	IDatabase* m_database;
};