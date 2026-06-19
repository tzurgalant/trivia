#include "RoomMemberRequestHandler.h"
#include "MenuRequestHandler.h"
#include "JsonResponsePacketSerializer.h"
#include "JsonRequestPacketDeserializer.h"
#include "RequestHandlerFactory.h"
RoomMemberRequestHandler::RoomMemberRequestHandler(RequestHandlerFactory& handlerFactory, RoomManager roomManager, LoggedUser Luser, Room& room):m_handlerFactory(handlerFactory), m_roomManager(roomManager), m_user(Luser), m_room(room)
{

}
bool RoomMemberRequestHandler::isRequestRelevant(const RequestInfo& reqInfo)
{
	return reqInfo.id == LeaveRoomCmd || reqInfo.id == GetRoomStateCmd ||
		reqInfo.id == GetPlayersInRoomCmd;
}
RequestResult RoomMemberRequestHandler::handleRequest(const RequestInfo& reqInfo)
{
	switch (reqInfo.id)
	{
	case LeaveRoomCmd:
		return leaveRoom(reqInfo);

	case GetRoomStateCmd:
		return getRoomState(reqInfo);

	case GetPlayersInRoomCmd:
		return getPlayersInRoom(reqInfo);
	default:
		throw std::runtime_error("Invalid request for RoomAdminRequestHandler");
	}
}


RequestResult RoomMemberRequestHandler::leaveRoom(const RequestInfo& reqInfo)
{

	LeaveRoomResponse response;
	RequestResult res;
	response.status = m_room.removeUser(m_user);
	res.response = JsonResponsePacketSerializer::serializeResponse(response);
	res.newHandler = m_handlerFactory.createMenuRequestHanlder(m_user);
	return res;
}
RequestResult RoomMemberRequestHandler::getRoomState(const RequestInfo& reqInfo)
{
	RequestResult res;
	GetRoomStateResponse response;

	try
	{
		response.answerTimeOut = m_room.getRoomData().timePerQuestion;
		response.players = m_room.getAllUsersNames();
		response.hasGameBegun = m_room.getRoomData().status;
		response.questionCount = m_room.getRoomData().numOfQuestionsInGame;
		response.status = true;
		res.newHandler = nullptr;
		res.response = JsonResponsePacketSerializer::serializeResponse(response);

	}
	catch (const std::exception& e)
	{
		throw std::runtime_error("Room was delete!!");
	}
	return res;
}
RequestResult RoomMemberRequestHandler::getPlayersInRoom(const RequestInfo& reqInfo)
{
	RequestResult res;
	GetPlayersInRoomResponse playersInRoomResponse;
	GetPlayersinRoomRequest playersinRoomRequest = JsonRequestPacketDeserializer::deserializeGetPlayersRequest(reqInfo.buff);
	try
	{
		playersInRoomResponse.players = m_handlerFactory.getRoomManager().getRoom(playersinRoomRequest.roomld)->getAllUsersNames();
		res.newHandler = nullptr;//stay the same satge
		res.response = JsonResponsePacketSerializer::serializeResponse(playersInRoomResponse);
	}
	catch (const std::exception& e)
	{
		throw std::runtime_error("Room was delete!!");

	}
	return res;
}
