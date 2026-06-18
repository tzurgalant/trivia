#include "Game.h"
#include <algorithm> 
#include <iterator>  
Game::Game(unsigned int gameId,std::vector<Question> questions, std::map<LoggedUser, GameData>players):m_gameId(gameId),m_questions(questions),m_players(players)
{
}
Question Game::getQuesionForUser(LoggedUser u)
{
	Question curr = m_players[u].currentQuestion;
	auto it = std::find(m_questions.begin(), m_questions.end(), curr);

	m_players[u].currentQuestion = *it++;
	return *it++;
} 
int Game::submitAnswer(LoggedUser u,unsigned int answerId)
{
	int currectAnsId = m_players[u].currentQuestion.getCorrectAnswerId();
	if (currectAnsId = answerId)
	{
		m_players[u].correctAnswerCount++;
	}
	else
	{
		m_players[u].wrongAnswerCount++;
	}
	return currectAnsId;
}
void Game::removePlayer(LoggedUser u)
{
	m_players.erase(u);
}
unsigned int Game::getGameID() const
{
	return m_gameId;
}
std::map<LoggedUser, GameData>& Game::getPlayers()
{
	return m_players;
}