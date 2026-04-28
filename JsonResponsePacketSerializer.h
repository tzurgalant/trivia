#pragma once
#include <iostream>

#include "IRequestHandler.h"



class JsonResponsePacketSerializer
{
public:
	static Buffer serializeResponse(LoginResponse req);
	static Buffer serializeResponse(SignupResponse req);
private:
};