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
	GetPlayersinRoomRequest deserializeGetPlayersRequest(const Buffer& buffer);
	JoinRoomRequest deserializeJoinRoomRequest(const Buffer& buffer);
	CreateRoomRequest deserializeCreateRoomRequest(const Buffer& buffer);
private:

};