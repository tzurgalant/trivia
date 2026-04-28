#pragma once
#include <iostream>

#include "IRequestHandler.h"
class JsonRequestPacketSerializer
{
public:
	static LoginRequest serializeLoginRequest(const Buffer& buffer);
	static SignupRequest serializeSignupRequest(const Buffer& buffer);
private:

};