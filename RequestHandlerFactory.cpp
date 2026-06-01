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

RoomMemberRequestHandler* RequestHandlerFactory::createRoomMemberRequestHandler(RequestHandlerFactory& handlerFactory, RoomManager roomManager, LoggedUser Luser, Room& room)
{
    return new RoomMemberRequestHandler(handlerFactory, roomManager, Luser, room);
}
RoomAdminRequestHandler* RequestHandlerFactory::createRoomAdminRequestHandler(Room& room, LoggedUser Luser, RoomManager& roomManager, RequestHandlerFactory& handlerFactory)
{
    return new RoomAdminRequestHandler(room, Luser,roomManager, handlerFactory);
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

