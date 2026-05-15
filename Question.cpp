#include "Question.h"

Question::Question(const std::string question, const std::vector<std::string>& possibleAnswers, int correctAnswer)
{
	m_question = question;
	m_possibleAnswers = possibleAnswers;
	m_correctAnswer = correctAnswer;
}

std::string Question::getQuestion() const
{
	return m_question;
}

std::vector<std::string> Question::getPossibleAnswers() const
{
	return m_possibleAnswers;
}

int Question::getCorrectAnswerId() const
{
	return m_correctAnswer;
}