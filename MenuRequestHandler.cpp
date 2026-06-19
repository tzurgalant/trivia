#include "MenuRequestHandler.h"
#include "LoginRequestHandler.h"
#include "RoomMemberRequestHandler.h"
#include "RoomAdminRequestHandler.h"
#include "JsonResponsePacketSerializer.h"
#include "JsonRequestPacketDeserializer.h"

MenuRequestHandler::MenuRequestHandler(RequestHandlerFactory& handlerFactory, LoggedUser Luser):m_handlerFactory(handlerFactory),m_user(Luser)
{

}
MenuRequestHandler::~MenuRequestHandler()
{
	 
}

bool MenuRequestHandler::isRequestRelevant(const RequestInfo& reqInfo)
{
    return reqInfo.id == LogoutCmd ||
        reqInfo.id == GetRoomsCmd ||
        reqInfo.id == GetPlayersInRoomCmd ||
        reqInfo.id == GetPersonalStatsCmd ||
        reqInfo.id == GetHighScoreCmd ||
        reqInfo.id == JoinRoomCmd ||
        reqInfo.id == CreateRoomCmd;
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
    default:
        throw std::runtime_error("Irrelevant request in MenuRequestHandler");
    }
}
RequestResult MenuRequestHandler::logout(const RequestInfo& reqInfo)
{ 
    RequestResult res;
    LogoutResponse logoutResponse;

    m_handlerFactory.getLoginManager().log_off(m_user.getUserName());
    logoutResponse.status = 1;
    res.newHandler = m_handlerFactory.createLoginRequestHandler();
    res.response = JsonResponsePacketSerializer::serializeResponse(logoutResponse);
    return res;
}
RequestResult MenuRequestHandler::getRooms(const RequestInfo& reqInfo)
{ 
    RequestResult res;
    GetRoomsResponse roomsResponse;

    roomsResponse.rooms = m_handlerFactory.getRoomManager().getRooms();
    //std::cout << "rooms in server:" << std::endl;
    //for (auto room : roomsResponse.rooms)
    //{
    //    std::cout << room.id << std::endl;
    //}
    roomsResponse.status = 1;
    res.newHandler = nullptr;
    res.response = JsonResponsePacketSerializer::serializeResponse(roomsResponse);
    return res;
}
RequestResult MenuRequestHandler::getPlayersInRoom(const RequestInfo& reqInfo)
{
    RequestResult res;
    GetPlayersInRoomResponse playersInRoomResponse;
    GetPlayersinRoomRequest playersinRoomRequest = JsonRequestPacketDeserializer::deserializeGetPlayersRequest(reqInfo.buff);

    playersInRoomResponse.players = m_handlerFactory.getRoomManager().getRoom(playersinRoomRequest.roomld)->getAllUsersNames();
    
    res.newHandler = nullptr;
    res.response = JsonResponsePacketSerializer::serializeResponse(playersInRoomResponse);
    return res;
}
RequestResult MenuRequestHandler::getPersonalStats(const RequestInfo& reqInfo)
{ 
    RequestResult res;
    GetPersonalStatsReponse personalStatsReponse;


    personalStatsReponse.statistics = m_handlerFactory.getStatisticsManager().getUserStatistics(m_user.getUserName());
    personalStatsReponse.status = 1;
    res.newHandler = nullptr;
    res.response = JsonResponsePacketSerializer::serializeResponse(personalStatsReponse);
    return res;
}

RequestResult MenuRequestHandler::getHighScore(const RequestInfo& reqInfo)
{ 
    RequestResult res;
    GetHighScoreResponse highScoreResponse;


    highScoreResponse.statistics = m_handlerFactory.getStatisticsManager().getHighScore();
    highScoreResponse.status = 1;
    res.newHandler = nullptr;
    res.response = JsonResponsePacketSerializer::serializeResponse(highScoreResponse);
    return res;
}
RequestResult MenuRequestHandler::joinRoom(const RequestInfo& reqInfo)
{
    RequestResult res;
    JoinRoomResponse JoinRoomResponse;
    JoinRoomRequest joinRoomRequest = JsonRequestPacketDeserializer::deserializeJoinRoomRequest(reqInfo.buff);

    try
    {
        Room* room = m_handlerFactory.getRoomManager().getRoom(joinRoomRequest.roomld);

        if (room->addUser(m_user))
        {
            JoinRoomResponse.status = 1;
            res.newHandler = m_handlerFactory.createRoomMemberRequestHandler(m_handlerFactory.getRoomManager(), m_user,*m_handlerFactory.getRoomManager().getRoom(joinRoomRequest.roomld));// for now we dont have next state...
        }
        else// the room is full 
        {
            JoinRoomResponse.status = 0;
            res.newHandler = nullptr;
        }
    }
    catch (const std::out_of_range& e)// the getRoom function not succes 
    {
        JoinRoomResponse.status = 0;
        res.newHandler = nullptr;
    }

    res.response = JsonResponsePacketSerializer::serializeResponse(JoinRoomResponse);
    return res;
}
RequestResult MenuRequestHandler::createRoom(const RequestInfo& reqInfo)
{
    RequestResult res;
    CreateRoomResponse createRoomResponse;
    CreateRoomRequest createRoomRequest = JsonRequestPacketDeserializer::deserializeCreateRoomRequest(reqInfo.buff);

    RoomData roomData;
    roomData.name = createRoomRequest.roomName;
    roomData.maxPlayers = createRoomRequest.maxUsers;
    roomData.numOfQuestionsInGame = createRoomRequest.questionCount;
    roomData.timePerQuestion = createRoomRequest.answerTimeout;
    roomData.status = false;//if game was started

    createRoomResponse.roomId = m_handlerFactory.getRoomManager().createRoom(m_user, roomData);
    createRoomResponse.status = 1;

    res.newHandler = m_handlerFactory.createRoomAdminRequestHandler(*m_handlerFactory.getRoomManager().getRoom(createRoomResponse.roomId),m_user,m_handlerFactory.getRoomManager());// for now we dont have next state...
    res.response = JsonResponsePacketSerializer::serializeResponse(createRoomResponse);
    return res;
}