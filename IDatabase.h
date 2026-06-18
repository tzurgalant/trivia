#pragma once

#include <iostream>
#include <list>
#include "Question.h"
#include "Game.h"
class IDatabase
{
public:
	virtual bool open() = 0;
	virtual bool close() = 0;

	//user related
	virtual bool doesUserExist(std::string name) = 0;
	virtual bool doesPasswordMatch(std::string userName, std::string password) = 0;
	virtual bool addNewUser(std::string name, std::string pass, std::string email) = 0;

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
	virtual bool submitGameStatsToDB(std::string playerName, GameData& data) = 0;

};