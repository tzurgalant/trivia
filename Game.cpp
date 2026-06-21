#include "Game.h"
#include <algorithm> 
#include <iterator> 
#include <chrono>

Game::Game(unsigned int gameId, std::vector<Question> questions, std::map<LoggedUser, GameData> players)
    : m_gameId(gameId), m_questions(questions), m_players(players)
{
}

Question* Game::getQuesionForUser(const LoggedUser& u)
{
    auto playerIt = m_players.find(u);

    if (playerIt == m_players.end())
    {
        return nullptr;
    }

    Question currentQ = playerIt->second.currentQuestion;

    if (currentQ.getQuestion().empty())
    {
        return nullptr;
    }

    auto it = std::find(m_questions.begin(), m_questions.end(), currentQ);

    if (it != m_questions.end())
    {
        playerIt->second.startTime = std::chrono::steady_clock::now();
        return &(*it);
    }

    return nullptr;
}

int Game::submitAnswer(const LoggedUser& u, unsigned int answerId) 
{
    auto playerIt = m_players.find(u);
    if (playerIt == m_players.end())
    {
        return -1; 
    }

    auto endTime = std::chrono::steady_clock::now();
    unsigned int secondsPassed = static_cast<unsigned int>(
        std::chrono::duration_cast<std::chrono::seconds>(endTime - playerIt->second.startTime).count()
        );

    int currectAnsId = playerIt->second.currentQuestion.getCorrectAnswerId() - 1;
    if (currectAnsId == answerId)
    {
        playerIt->second.correctAnswerCount++;
    }
    else
    {
        playerIt->second.wrongAnswerCount++;
    }

    int totalAnswers = playerIt->second.correctAnswerCount + playerIt->second.wrongAnswerCount;
    if (totalAnswers == 1)
    {
        playerIt->second.averageAnswerTime = secondsPassed;
    }
    else
    {
        playerIt->second.averageAnswerTime = ((playerIt->second.averageAnswerTime * (totalAnswers - 1)) + secondsPassed) / totalAnswers;
    }

    auto it = std::find(m_questions.begin(), m_questions.end(), playerIt->second.currentQuestion);
    if (it != m_questions.end() && (it + 1) != m_questions.end())
    {
        playerIt->second.currentQuestion = *(it + 1); 
    }
    else
    {
        playerIt->second.currentQuestion = Question();
    }
    return currectAnsId;
}

void Game::removePlayer(LoggedUser u)
{
    if (m_players.find(u) != m_players.end())
    {
        m_players.erase(u);
    }
}

unsigned int Game::getGameID() const
{
    return m_gameId;
}

std::map<LoggedUser, GameData>& Game::getPlayers()
{
    return m_players;
}

bool Game::isGameStop() const
{
    for (const auto& player : m_players)
    {
        if (!player.second.currentQuestion.getQuestion().empty())
        {
            return false;
        }
    }
    return true;
}