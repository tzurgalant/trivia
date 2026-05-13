#pragma once
#include <iostream>

#include "IRequestHandler.h"



class JsonResponsePacketSerializer
{
public:
	static Buffer serializeResponse(LoginResponse req);
	static Buffer serializeResponse(SignupResponse req);
	static Buffer serializerReqponse(ErrorResponse req);
	static Buffer serializerReqponse(LogoutResponse req);
	static Buffer serializerReqponse(GetRoomsResponse req);
	static Buffer serializerReqponse(GetPlayersInRoomResponse req);
	static Buffer serializerReqponse(JoinRoomResponse req);
	static Buffer serializerReqponse(CreateRoomResponse req);
	static Buffer serializerReqponse(GetHighScoreResponse req);
	static Buffer serializerReqponse(GetPersonalStatsReponse req);
private:
};