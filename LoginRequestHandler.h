#pragma once

#include "IRequestHandler.h"

#include <string>
class LoginRequestHandler: public IRequestHandler
{
public:
	LoginRequestHandler();
	~LoginRequestHandler();

	 bool isRequestRelevant(const RequestInfo& reqInfo) override;
	 RequestResult handleRequest(const RequestInfo& reqInfo) override;
private:
	RequestResult signup(const RequestInfo& reqInfo);
	RequestResult login(const RequestInfo& reqInfo);
};