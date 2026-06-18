#pragma once
#include "IDatabase.h"
#include "Question.h"
#include <io.h>   
#include "sqlite3.h"
#include <list>
#include <vector>
#include <algorithm>

class SqliteDatabase :public IDatabase
{
public:
	SqliteDatabase();
	~SqliteDatabase();

	bool open() override;
	bool close() override;

	//users related
	bool doesUserExist(std::string name) override;
	bool doesPasswordMatch(std::string name, std::string pass2)  override;
	bool addNewUser(std::string name, std::string pass, std::string email) override;

	//questions related
	std::list<Question> getQuestions(int num) override;

	//statistics related
	float getPlayerAverageAnswerTime(std::string userName) override;
	int getNumOfCorrectAnswers(std::string) override;
	int getNumOfTotalAnswers(std::string) override;
	int getNumOfPlayerGames(std::string) override;

	//scores
	int getPlayerScore(std::string) override;
	std::vector<std::string> getHighScores() override;
	bool submitGameStatsToDB(std::string playerName, GameData &data) override;

private:
	sqlite3* _db = nullptr;
	std::string _dbFileName;
};

