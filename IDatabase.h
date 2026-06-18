#pragma once

#include <iostream>
#include <list>
#include "Question.h"

class IDatabase
{
public:
	virtual bool open() = 0;
	virtual bool close() = 0;

	//user related
	virtual int doesUserExist(std::string name) = 0;
	virtual int doesPasswordMatch(std::string userName, std::string password) = 0;
	virtual int addNewUser(std::string name, std::string pass, std::string email) = 0;

	//question related
	virtual std::list<Question> getQuestions(int num) = 0;

	//statistics related
	virtual float getPlayerAverageAnswerTime(std::string userName) = 0;
	virtual int getNumOfCorrectAnswers(std::string userName) = 0;
	virtual int getNumOfTotalAnswers(std::string userName) = 0;
	virtual int getNumOfPlayerGames(std::string userName) = 0;

	//scores
	virtual int getPlayerScore(std::string userName) = 0;
	virtual std::vector<std::string> getHighScores() = 0;
	virtual int submitGameStatsToDB(std::string playerName, GameData) = 0;

};