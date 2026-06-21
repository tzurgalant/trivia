#include "GameRequestHandler.h"
#include "JsonResponsePacketSerializer.h"
#include "JsonRequestPacketDeserializer.h"
#include "MenuRequestHandler.h"

GameRequestHandler::GameRequestHandler(Game& game, LoggedUser user, GameManager& gm, RequestHandlerFactory& rhf):m_game(game),m_user(user),m_gameManager(gm),m_handlerFactory(rhf)
{
}

bool GameRequestHandler::isRequestRelevant(const RequestInfo& info)
{
	return info.id == GetGameResultsCmd || info.id == SubmitAnswerCmd || info.id == GetQuestionCmd || info.id == LeaveGameCmd;
}
RequestResult GameRequestHandler::handleRequest(const RequestInfo& info) 
{
	switch (info.id)
	{
	case GetGameResultsCmd:
		return getGameResults(info);
		break;
	case SubmitAnswerCmd:
		return submitAnswer(info);
		break;
	case GetQuestionCmd:
		return getQuestion(info);
		break;
	case LeaveGameCmd:
		return leaveGame(info);
		break;
	}
}


RequestResult GameRequestHandler::getQuestion(const RequestInfo& info)
{
	RequestResult result = {};
	GetQuestionResponse response = {};
	std::vector<std::string> answersS;
	std::map<unsigned int, std::string> answersM;
	Question* qes;
	int i = 0;

	try// if will crush on the procces to get question data its mean the game is close!!!
	{
		qes = m_game.getQuesionForUser(m_user);
		if (qes != nullptr)// if he goet here this mean that the game is ruuning but he finshe the quesitons...
		{
			answersS = qes->getPossibleAnswers();

			for (auto answers : answersS)
			{
				answersM[i] = answers;
				i++;
			}
			response.answers = answersM;
			response.question = qes->getQuestion();
			response.status = 1;
		}
		else
		{
			response.status = 0;
		}
	}
	catch (const std::exception& e)
	{
		throw std::runtime_error("Game was closed!!");
	}
	result.response = JsonResponsePacketSerializer::serializeResponse(response);
	result.newHandler = nullptr;// stay the same state
	return result;
}
RequestResult GameRequestHandler::submitAnswer(const RequestInfo& info)
{
	RequestResult result = {};
	SubmitAnswerRequest requestPara = JsonRequestPacketDeserializer::deserializeSubmitAnswerRequest(info.buff);
	SubmitAnswerResponse response = {};
	
	try// if will crush on the procces to get question data its mean the game is close!!!
	{
		response.correctAnswerId = m_game.submitAnswer(m_user, requestPara.answerId);
		response.status = 1;
	}
	catch (const std::exception& e)
	{
		throw std::runtime_error("Game was closed!!");
	}
	result.response = JsonResponsePacketSerializer::serializeResponse(response);
	result.newHandler = nullptr;// stay the same state
	return result;
}
RequestResult GameRequestHandler::getGameResults(const RequestInfo& info)
{
	RequestResult result = {};
	GetGameResultsResponse response = {};

	try// if will crush on the procces to get question data its mean the game is close!!!
	{
		if (m_game.isGameStop())// stop not mean deleted its mean that all the users finshe ther question...
		{
			std::map<LoggedUser, GameData> players = m_game.getPlayers();
			std::vector<PlayerResult> results;
			for (auto player : players)
			{
				PlayerResult playerResult = {player.first.getUserName(),player.second.correctAnswerCount,player.second.wrongAnswerCount,player.second.averageAnswerTime };
				results.push_back(playerResult);
			}
			response.results = results;
			response.status = 1;
		}
		else
		{
			response.status = 0;
		}
	}
	catch (const std::exception& e)
	{
		throw std::runtime_error("Game was closed!!");
	}
	result.response = JsonResponsePacketSerializer::serializeResponse(response);
	result.newHandler = nullptr;
	return result;
}
RequestResult GameRequestHandler::leaveGame(const RequestInfo& info)
{
	RequestResult result = {};
	LeaveGameResponse response = {};

	try// if will crush on the procces to get question data its mean the game is close!!!
	{
		m_game.removePlayer(m_user);
	}
	catch (const std::exception& e)
	{
		throw std::runtime_error("Game was closed!!");
	}
	response.status = 1;
	result.response = JsonResponsePacketSerializer::serializeResponse(response);
	result.newHandler = m_handlerFactory.createMenuRequestHanlder(m_user);
	return result;
}
