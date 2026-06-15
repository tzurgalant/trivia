#pragma once

#include "Question.h"
#include "LoggedUser.h"
#include <map>


struct GameData
{
	Question currentQuestion;
	unsigned int correctAnswerCount;
	unsigned int wrongAnswerCount;
	unsigned int averageAnswerTime;
};

class Game
{
public:
	

private:
	std::vector<Question> m_qustions;
	std::map<LoggedUser, GameData>m_players;
	unsigned int m_gameId;
};

