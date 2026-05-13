#include "MenuRequestHandler.h"

MenuRequestHandler::MenuRequestHandler(RequestHandlerFactory& handlerFactory):m_handlerFactory(handlerFactory)
{ 
}
MenuRequestHandler::~MenuRequestHandler()
{
	 
}

bool MenuRequestHandler::isRequestRelevant(const RequestInfo& reqInfo)
{
	return false;
}
RequestResult MenuRequestHandler::handleRequest(const RequestInfo& reqInfo)
{
	return RequestResult();
}