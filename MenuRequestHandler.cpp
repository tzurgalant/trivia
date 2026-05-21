#include "MenuRequestHandler.h"
#include "LoginRequestHandler.h"
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
    roomsResponse.status = 1;
    res.newHandler = nullptr;// for now we dont have next state...
    res.response = JsonResponsePacketSerializer::serializeResponse(roomsResponse);
    return res;
}
RequestResult MenuRequestHandler::getPlayersInRoom(const RequestInfo& reqInfo)
{
    RequestResult res;
    GetPlayersInRoomResponse playersInRoomResponse;
    GetPlayersinRoomRequest playersinRoomRequest = JsonRequestPacketDeserializer::deserializeGetPlayersRequest(reqInfo.buff);

    playersInRoomResponse.players = m_handlerFactory.getRoomManager().getRoom(playersinRoomRequest.roomld).getAllUsersNames();
    res.newHandler = nullptr;// for now we dont have next state...
    res.response = JsonResponsePacketSerializer::serializeResponse(playersInRoomResponse);
    return res;
}
RequestResult MenuRequestHandler::getPersonalStats(const RequestInfo& reqInfo)
{ 
    RequestResult res;
    GetPersonalStatsReponse personalStatsReponse;


    personalStatsReponse.statistics = m_handlerFactory.getStatisticsManager().getUserStatistics(m_user.getUserName());
    personalStatsReponse.status = 1;
    res.newHandler = nullptr;// for now we dont have next state...
    res.response = JsonResponsePacketSerializer::serializeResponse(personalStatsReponse);
    return res;
}

RequestResult MenuRequestHandler::getHighScore(const RequestInfo& reqInfo)
{ 
    RequestResult res;
    GetHighScoreResponse highScoreResponse;


    highScoreResponse.statistics = m_handlerFactory.getStatisticsManager().getHighScore();
    highScoreResponse.status = 1;
    res.newHandler = nullptr;// for now we dont have next state...
    res.response = JsonResponsePacketSerializer::serializeResponse(highScoreResponse);
    return res;
}
RequestResult MenuRequestHandler::joinRoom(const RequestInfo& reqInfo)
{
    RequestResult res;
    JoinRoomResponse JoinRoomResponse;
    JoinRoomRequest joinRoomRequest = JsonRequestPacketDeserializer::deserializeJoinRoomRequest(reqInfo.buff);

    if (m_handlerFactory.getRoomManager().getRoomState(joinRoomRequest.roomld))
    {
        m_handlerFactory.getRoomManager().getRoom(joinRoomRequest.roomld).addUser(m_user);
        JoinRoomResponse.status = 1;

    }
    else
    {
        JoinRoomResponse.status = 0;
    }
    res.newHandler = nullptr;// for now we dont have next state...
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
    roomData.status = 1;// wiil be active if you create room its add the logged user...

    m_handlerFactory.getRoomManager().createRoom(m_user, roomData);
    createRoomResponse.status = 1;
    res.newHandler = nullptr;// for now we dont have next state...
    res.response = JsonResponsePacketSerializer::serializeResponse(createRoomResponse);
    return res;
}