#include "LoginRequestHandler.h"
#include "MenuRequestHandler.h"

RequestHandlerFactory::RequestHandlerFactory(IDatabase* database) : m_loginManager(database)
{

}
RequestHandlerFactory::~RequestHandlerFactory()
{

}

void RequestHandlerFactory::changeRequestHandler(RequestResult* res, IRequestHandler* newHandler)
{
	if (newHandler != nullptr)
	{
		if (res->newHandler != nullptr)
		{
			delete res->newHandler;
		}
		res->newHandler = newHandler;
	}
}


MenuRequestHandler* RequestHandlerFactory::createMenuRequestHanlder()
{
	return new  MenuRequestHandler(*this);
}

LoginRequestHandler* RequestHandlerFactory::createLoginRequestHandler()
{
	return new LoginRequestHandler(*this);
}
LoginManager& RequestHandlerFactory::getLoginManager() 
{
	return m_loginManager;
}