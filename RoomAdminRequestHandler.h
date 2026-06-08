#pragma once

#include "IRequestHandler.h"
#include "RequestHandlerFactory.h"
#include "RoomManager.h"
#include "LoggedUser.h"

class RoomAdminRequestHandler : public IRequestHandler
{
public:
    RoomAdminRequestHandler(Room& room,
                            LoggedUser user,
                            RoomManager& roomManager,
                            RequestHandlerFactory& factory);

    bool isRequestRelevant(const RequestInfo& reqInfo) override;
    RequestResult handleRequest(const RequestInfo& reqInfo) override;

private:
    Room& m_room;
    LoggedUser m_user;
    RoomManager& m_roomManager;
    RequestHandlerFactory& m_handlerFactory;

    RequestResult closeRoom(const RequestInfo& reqInfo);
    RequestResult startGame(const RequestInfo& reqInfo);
    RequestResult getRoomState(const RequestInfo& reqInfo);
    RequestResult getPlayersInRoom(const RequestInfo& reqInfo);

};