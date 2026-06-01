#include "RoomAdminRequestHandler.h"
#include "JsonResponsePacketSerializer.h"
#include "JsonRequestPacketDeserializer.h"

RoomAdminRequestHandler::RoomAdminRequestHandler(
    Room& room,
    LoggedUser user,
    RoomManager& roomManager,
    RequestHandlerFactory& factory)
    : m_room(room),
    m_user(user),
    m_roomManager(roomManager),
    m_handlerFactory(factory)
{
}

bool RoomAdminRequestHandler::isRequestRelevant(const RequestInfo& reqInfo)
{
    return reqInfo.id == CloseRoomCmd ||
        reqInfo.id == StartGameCmd ||
        reqInfo.id == GetRoomStateCmd;
}

RequestResult RoomAdminRequestHandler::handleRequest(const RequestInfo& reqInfo)
{
    switch (reqInfo.id)
    {
    case CloseRoomCmd:
        return closeRoom(reqInfo);

    case StartGameCmd:
        return startGame(reqInfo);

    case GetRoomStateCmd:
        return getRoomState(reqInfo);

    default:
        throw std::runtime_error("Invalid request for RoomAdminRequestHandler");
    }
}

RequestResult RoomAdminRequestHandler::closeRoom(const RequestInfo& reqInfo)
{
    RequestResult res;
    
    m_roomManager.deleteRoom(m_room.getRoomData().id);

    CloseRoomResponse resp;
    resp.status = 1;

    res.response = JsonResponsePacketSerializer::serializeResponse(resp);
    res.newHandler = m_handlerFactory.createMenuRequestHanlder(m_user);
}