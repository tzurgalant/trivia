#pragma once
#include <iostream>

#include "IRequestHandler.h"
class JsonRequestPacketDeserializer
{
public:
	//login related
	static LoginRequest deserializeLoginRequest(const Buffer& buffer);
	static SignupRequest deserializeSignupRequest(const Buffer& buffer);

	//rooms related
	static GetPlayersinRoomRequest deserializeGetPlayersRequest(const Buffer& buffer);
	static JoinRoomRequest deserializeJoinRoomRequest(const Buffer& buffer);
	static CreateRoomRequest deserializeCreateRoomRequest(const Buffer& buffer);

	//game related
	SubmitAnswerRequest deserializeSubmitAnswerRequest(const std::string& buffer);
private:

};