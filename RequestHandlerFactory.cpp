#include "LoginRequestHandler.h"
#include "MenuRequestHandler.h"

RequestHandlerFactory::RequestHandlerFactory(IDatabase* database) : m_loginManager(database),m_statisticsManager(database)
{

}
RequestHandlerFactory::~RequestHandlerFactory()
{

}

void RequestHandlerFactory::changeRequestHandler(RequestResult* res, IRequestHandler*& reqHandler)
{
    if (res->newHandler != nullptr)
    {
        if (reqHandler != nullptr)
        {
            delete reqHandler;
        }

        reqHandler = res->newHandler;
    }
}


MenuRequestHandler* RequestHandlerFactory::createMenuRequestHanlder(LoggedUser Luser)
{
	return new  MenuRequestHandler(*this,Luser);
}


LoginRequestHandler* RequestHandlerFactory::createLoginRequestHandler()
{
	return new LoginRequestHandler(*this);
}
LoginManager& RequestHandlerFactory::getLoginManager() 
{
	return m_loginManager;
}

RoomManager& RequestHandlerFactory::getRoomManager()
{
    return m_roomManager;
}

StatisticsManager& RequestHandlerFactory::getStatisticsManager()
{
    return m_statisticsManager;
}
