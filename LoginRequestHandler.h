#pragma once

#include "IRequestHandler.h"
#include "RequestHandlerFactory.h"
#include <string>
class LoginRequestHandler: public IRequestHandler
{
public:
	LoginRequestHandler(RequestHandlerFactory& handlerFactory);
	~LoginRequestHandler();

	 bool isRequestRelevant(const RequestInfo& reqInfo) override;
	 RequestResult handleRequest(const RequestInfo& reqInfo) override;
private:
	RequestHandlerFactory& m_handlerFactory;
	RequestResult signup(const RequestInfo& reqInfo);
	RequestResult login(const RequestInfo& reqInfo);
};