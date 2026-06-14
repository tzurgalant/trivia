#pragma once

#include "IRequestHandler.h"
#include "RequestHandlerFactory.h"
#include "loginManager.h"
#include "RoomManager.h"

class MenuRequestHandler : public IRequestHandler
{
public:
	MenuRequestHandler(RequestHandlerFactory& handlerFactory, LoggedUser Luser);
	~MenuRequestHandler();

	bool isRequestRelevant(const RequestInfo& reqInfo) override;
	RequestResult handleRequest(const RequestInfo& reqInfo) override;

private:
	LoggedUser m_user;
	RequestHandlerFactory& m_handlerFactory;

	RequestResult logout(const RequestInfo& reqInfo);
	RequestResult getRooms(const RequestInfo& reqInfo);
	RequestResult getPlayersInRoom(const RequestInfo& reqInfo);
	RequestResult getPersonalStats(const RequestInfo& reqInfo);
	RequestResult getHighScore(const RequestInfo& reqInfo);
	RequestResult joinRoom(const RequestInfo& reqInfo);
	RequestResult createRoom(const RequestInfo& reqInfo);
};