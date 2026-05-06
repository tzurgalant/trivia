#include "SqliteDatabase.h"


SqliteDatabase::SqliteDatabase()
{ }
SqliteDatabase::~SqliteDatabase()
{ }

bool SqliteDatabase::open() 
{ }
bool SqliteDatabase::close() 
{ }
int SqliteDatabase::doesUserExist(std::string name) 
{ }
int SqliteDatabase::doesPasswordMatch(std::string pass1, std::string pass2)
{ }
int SqliteDatabase::addNewUser(std::string name, std::string pass, std::string email)
{ }
