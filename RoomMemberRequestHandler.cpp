#include "RoomMemberRequestHandler.h"
#include "JsonResponsePacketSerializer.h"
RoomMemberRequestHandler::RoomMemberRequestHandler(RequestHandlerFactory& handlerFactory, RoomManager roomManager, LoggedUser Luser, RoomData& roomData):m_handlerFactory(handlerFactory), m_roomManager(roomManager), m_user(Luser), m_room(roomData)
{
	
}
bool RoomMemberRequestHandler::isRequestRelevant(const RequestInfo& reqInfo)
{
	return reqInfo.id == LeaveRoomCmd || reqInfo.id == GetRoomStateCmd;
}
RequestResult RoomMemberRequestHandler::handleRequest(const RequestInfo& reqInfo)
{
	return  reqInfo.id == LeaveRoomCmd ? leaveRoom(reqInfo) : getRoomState(reqInfo);
}

RequestResult RoomMemberRequestHandler::leaveRoom(const RequestInfo& reqInfo)
{
	LeaveRoomResponse response;
	RequestResult res;
	response.status = m_room.removeUser(m_user);
	res.response = JsonResponsePacketSerializer::serializeResponse(response);
	return res;
}
RequestResult RoomMemberRequestHandler::getRoomState(const RequestInfo& reqInfo)
{
	RequestResult result;
	GetRoomStateResponse response;
	response.answerTimeOut = m_room.getRoomData().timePerQuestion;
	response.players = m_room.getAllUsersNames();
	response.hasGameBegun = m_room.getRoomData().status;
	response.questionCount = m_room.getRoomData().numOfQuestionsInGame;
	response.status = true;
	result.response = JsonResponsePacketSerializer::serializeResponse(response);
	return result;
}