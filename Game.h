#pragma once

#include "Question.h"
#include "LoggedUser.h"
#include <map>
#include <chrono>

struct GameData
{
	Question currentQuestion;
	unsigned int correctAnswerCount;
	unsigned int wrongAnswerCount;
	unsigned int averageAnswerTime;

	std::chrono::steady_clock::time_point startTime;
};

class Game
{
public:	
	Game() = default;
	Game(unsigned int gameId,std::vector<Question> questions, std::map<LoggedUser, GameData>players);
	Question* getQuesionForUser(const LoggedUser& u);
	int submitAnswer(const LoggedUser& u,unsigned int answerId);
	void removePlayer(LoggedUser u);
	unsigned int getGameID() const;
	std::map<LoggedUser, GameData> &getPlayers();

	bool isGameStop() const;

	bool isSubmitted() const { return m_isSubmitted; }
	void setSubmitted(bool status) { m_isSubmitted = status; }
private:
	std::vector<Question> m_questions;
	std::map<LoggedUser, GameData>m_players;
	unsigned int m_gameId;
	bool m_isSubmitted = false;//defult not submitted...
};

