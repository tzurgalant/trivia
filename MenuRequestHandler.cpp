#include "MenuRequestHandler.h"

MenuRequestHandler::MenuRequestHandler(RequestHandlerFactory& handlerFactory):m_handlerFactory(handlerFactory)
{ 
}
MenuRequestHandler::~MenuRequestHandler()
{
	 
}

bool MenuRequestHandler::isRequestRelevant(const RequestInfo& reqInfo)
{
	return true;
}
RequestResult MenuRequestHandler::handleRequest(const RequestInfo& reqInfo)
{
	return RequestResult();
}