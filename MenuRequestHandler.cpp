#include "MenuRequestHandler.h"
#include "LoginRequestHandler.h"
#include "JsonResponsePacketSerializer.h"
MenuRequestHandler::MenuRequestHandler(RequestHandlerFactory& handlerFactory, LoggedUser Luser):m_handlerFactory(handlerFactory),m_user(Luser)
{

}
MenuRequestHandler::~MenuRequestHandler()
{
	 
}

bool MenuRequestHandler::isRequestRelevant(const RequestInfo& reqInfo)
{
	return false;
}
RequestResult MenuRequestHandler::handleRequest(const RequestInfo& reqInfo)
{
    switch (reqInfo.id)
    {
    case LogoutCmd:
        return logout(reqInfo);

    case GetRoomsCmd:
        return getRooms(reqInfo);

    case GetPlayersInRoomCmd:
        return getPlayersInRoom(reqInfo);

    case GetPersonalStatsCmd:
        return getPersonalStats(reqInfo);

    case GetHighScoreCmd: 
        return getHighScore(reqInfo);

    case JoinRoomCmd:   
        return joinRoom(reqInfo);

    case CreateRoomCmd:   
        return createRoom(reqInfo);
    }
}
RequestResult MenuRequestHandler::logout(const RequestInfo& reqInfo)
{ 
    RequestResult res;
    LogoutResponse response;

    m_handlerFactory.getLoginManager().log_off(m_user.getUserName());
    response.status = 1;
    res.newHandler = m_handlerFactory.createLoginRequestHandler();
    res.response = JsonResponsePacketSerializer::serializeResponse(response);
    return res;
}
RequestResult MenuRequestHandler::getRooms(const RequestInfo& reqInfo)
{ 
    RequestResult res;
    GetRoomsResponse response;

    response.rooms = m_handlerFactory.getRoomManager().getRooms();
    response.status = 1;
    res.newHandler = m_handlerFactory.createLoginRequestHandler();
    res.response = JsonResponsePacketSerializer::serializeResponse(response);
    return res;
}
RequestResult MenuRequestHandler::getPlayersInRoom(const RequestInfo& reqInfo)
{
}
RequestResult MenuRequestHandler::getPersonalStats(const RequestInfo& reqInfo)
{ 
}
RequestResult MenuRequestHandler::getHighScore(const RequestInfo& reqInfo)
{ 
}
RequestResult MenuRequestHandler::joinRoom(const RequestInfo& reqInfo)
{
}
RequestResult MenuRequestHandler::createRoom(const RequestInfo& reqInfo)
{
}