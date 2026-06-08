#pragma once
#include "IRequestHandler.h"
#include "Room.h"
#include "RequestHandlerFactory.h"


class RoomMemberRequestHandler : public IRequestHandler
{
public:
	RoomMemberRequestHandler(RequestHandlerFactory& handlerFactory, RoomManager roomManager, LoggedUser Luser, Room& room);
	bool isRequestRelevant(const RequestInfo& reqInfo) override;
	RequestResult handleRequest(const RequestInfo& reqInfo) override;

private:
	Room &m_room;
	LoggedUser m_user;
	RequestHandlerFactory& m_handlerFactory;
	RoomManager& m_roomManager;

	RequestResult leaveRoom(const RequestInfo& reqInfo);
	RequestResult getRoomState(const RequestInfo& reqInfo);
	RequestResult getPlayersInRoom(const RequestInfo& reqInfo);
};



