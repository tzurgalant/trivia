#include "RoomAdminRequestHandler.h"
#include "JsonResponsePacketSerializer.h"
#include "JsonRequestPacketDeserializer.h"
#include "MenuRequestHandler.h"
#include "GameRequestHandler.h"
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
        reqInfo.id == GetRoomStateCmd||
        reqInfo.id == GetPlayersInRoomCmd;
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
    case GetPlayersInRoomCmd:
        return getPlayersInRoom(reqInfo);
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

    return res;
}

RequestResult RoomAdminRequestHandler::startGame(const RequestInfo& reqInfo)
{
    RequestResult res = { {}, nullptr };
    Game game;
    StartGameResponse resp;
    
    try
    {
        Game game = m_handlerFactory.getGameManager().createGame(m_room);
        res.newHandler = m_handlerFactory.createGameRequestHandler(game, m_user, m_handlerFactory.getGameManager());


        m_room.setRoomStatus(true);
        resp.status = 1;

    }
    catch(const std::exception & e )
    {
        resp.status = 0;
        std::cout << "error on start game:" << e.what() << std::endl;
    }
    
    res.response = JsonResponsePacketSerializer::serializeResponse(resp);
    return res;
}

RequestResult RoomAdminRequestHandler::getRoomState(const RequestInfo& reqInfo)
{
    RequestResult res;

    GetRoomStateResponse resp;

    RoomData data = m_room.getRoomData();

    resp.status = 1;
    resp.hasGameBegun = m_room.getRoomData().status;
    resp.players = m_room.getAllUsersNames();
    resp.questionCount = data.numOfQuestionsInGame;
    resp.answerTimeOut = data.timePerQuestion;

    res.response = JsonResponsePacketSerializer::serializeResponse(resp);
    res.newHandler = nullptr;

    return res;
}
RequestResult RoomAdminRequestHandler::getPlayersInRoom(const RequestInfo& reqInfo)
{
    RequestResult res;
    GetPlayersInRoomResponse playersInRoomResponse;
    GetPlayersinRoomRequest playersinRoomRequest = JsonRequestPacketDeserializer::deserializeGetPlayersRequest(reqInfo.buff);

    playersInRoomResponse.players = m_handlerFactory.getRoomManager().getRoom(playersinRoomRequest.roomld)->getAllUsersNames();
    res.newHandler = nullptr;//stay the same satge
    res.response = JsonResponsePacketSerializer::serializeResponse(playersInRoomResponse);
    return res;
}
