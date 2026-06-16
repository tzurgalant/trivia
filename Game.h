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
	Game(std::vector<Question> questions, std::map<LoggedUser, GameData>players);
	Question getQuesionForUser(LoggedUser u);
	int submitAnswer(LoggedUser u,unsigned int answerId);
	void removePlayer(LoggedUser u);
private:
	std::vector<Question> m_questions;
	std::map<LoggedUser, GameData>m_players;
	unsigned int m_gameId;
};

