#include "Game.h"
#include <algorithm> 
#include <iterator> 
#include <chrono>

//timer varubles and fucnion 
auto start = std::chrono::steady_clock::now();
auto end = std::chrono::steady_clock::now();

auto duration = std::chrono::duration_cast<std::chrono::seconds>(end - start);

unsigned int secondsPassed = static_cast<unsigned int>(duration.count());

Game::Game(unsigned int gameId, std::vector<Question> questions, std::map<LoggedUser, GameData> players)
    : m_gameId(gameId), m_questions(questions), m_players(players)
{
}

Question* Game::getQuesionForUser(LoggedUser u)
{
    Question currentQ = m_players[u].currentQuestion;
    auto it = std::find(m_questions.begin(), m_questions.end(), currentQ);

    if (it != m_questions.end())
    {
        // Start input timer for this specific user
        m_players[u].startTime = std::chrono::steady_clock::now();
        return &(*it);
    }
    return nullptr;
}

int Game::submitAnswer(LoggedUser u, unsigned int answerId)
{
    auto endTime = std::chrono::steady_clock::now();
    unsigned int secondsPassed = static_cast<unsigned int>(
        std::chrono::duration_cast<std::chrono::seconds>(endTime - m_players[u].startTime).count()
        );

    // Calculate statistics and average answer time
    int totalAnswers = m_players[u].correctAnswerCount + m_players[u].wrongAnswerCount;
    if (totalAnswers == 0)
    {
        m_players[u].averageAnswerTime = secondsPassed;
    }
    else
    {
        m_players[u].averageAnswerTime = ((m_players[u].averageAnswerTime * totalAnswers) + secondsPassed) / (totalAnswers + 1);
    }

    int currectAnsId = m_players[u].currentQuestion.getCorrectAnswerId();
    if (currectAnsId == answerId)
    {
        m_players[u].correctAnswerCount++;
    }
    else
    {
        m_players[u].wrongAnswerCount++;
    }

    // Advance the player to the next question
    auto it = std::find(m_questions.begin(), m_questions.end(), m_players[u].currentQuestion);
    if (it != m_questions.end() && (it + 1) != m_questions.end())
    {
        m_players[u].currentQuestion = *(it + 1);
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

bool Game::isGameStop() const
{
    return m_players.empty();
}