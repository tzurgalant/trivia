#pragma once
#include "IRequestHandler.h"
#include "RoomMemberRequestHandler.h"
#include "RequestHandlerFactory.h"
#include "Room.h"


class RoomMemberRequestHandler : public IRequestHandler
{
public:
	RoomMemberRequestHandler(RequestHandlerFactory& handlerFactory, RoomManager roomManager, LoggedUser Luser, Room& room);
	bool isRequestRelevant(const RequestInfo& reqInfo) override;
	RequestResult handleRequest(const RequestInfo& reqInfo) override;

	RequestResult leaveRoom(const RequestInfo& reqInfo);
	RequestResult getRoomState(const RequestInfo& reqInfo);
private:
	Room m_room;
	LoggedUser m_user;
	RequestHandlerFactory& m_handlerFactory;
	RoomManager& m_roomManager;
};



