#pragma once

#include "IRequestHandler.h"
#include "RequestHandlerFactory.h"
#include "loginManager.h"
#include <string>

class MenuRequestHandler:public IRequestHandler
{
public:
	MenuRequestHandler(RequestHandlerFactory& handlerFactory);
	~MenuRequestHandler();

	bool isRequestRelevant(const RequestInfo& reqInfo) override;
	RequestResult handleRequest(const RequestInfo& reqInfo) override;
private:
	RequestHandlerFactory& m_handlerFactory;

};