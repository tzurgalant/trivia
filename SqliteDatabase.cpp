#include "SqliteDatabase.h"
#include <string>

SqliteDatabase::SqliteDatabase():IDatabase(), _dbFileName("DB")
{

}
SqliteDatabase::~SqliteDatabase()
{ }

bool SqliteDatabase::open() 
{
    char* errMes = nullptr;
    bool  doesFileExist = _access(_dbFileName.c_str(), 0) == 0;// if the file is exist before
    int res = sqlite3_open(_dbFileName.c_str(), &_db);
    if (!doesFileExist)
    {
        // create all the tables if the file wasnt exist before
        const char* sqlUsers = "CREATE TABLE IF NOT EXISTS USERS ("
            "NAME TEXT PRIMARY KEY NOT NULL,"
            "PASS TEXT NOT NULL,"
            "EMAIL TEXT NOT NULL); ";
        const char* sqlCommends[] = { sqlUsers};

        for (const char* cmd : sqlCommends) {
            res = sqlite3_exec(_db, cmd, nullptr, nullptr, &errMes);

            if (res != SQLITE_OK) {
                std::cout << "Error: " << errMes << std::endl;
                sqlite3_free(errMes);
                break;
            }
        }
    }
    const char* sqlEnableFK = "PRAGMA foreign_keys = ON;";// the gimini say that i need to add this beacuse in the defaluse the sql not enforce foreign key so if i not add this i wiil can delete user whit out delet is alcum first and not give me a error  
    res = sqlite3_exec(_db, sqlEnableFK, nullptr, nullptr, &errMes);
    if (res != SQLITE_OK) {
        std::cout << "SQL Error: " << errMes << std::endl;
        sqlite3_free(errMes);
    }
    return res == SQLITE_OK;

}
bool SqliteDatabase::close() 
{ 
    sqlite3_close(_db);
    _db = nullptr;
    return true;
}
int SqliteDatabase::doesUserExist(std::string name) 
{ 
    sqlite3_stmt* stmt = nullptr;

    std::string sqlCmd = "SELECT PASS FROM USERS WHERE NAME = '" + name + "';";

    if (sqlite3_prepare_v2(_db, sqlCmd.c_str(), -1, &stmt, nullptr) == SQLITE_OK)// if we success to make radey the commend we enter to loop to check each row if ther are a any row is say that we have user!
    {
        while (sqlite3_step(stmt) == SQLITE_ROW)
        {
            const unsigned char* pass = sqlite3_column_text(stmt, 0);
            if (pass)// we found a user whit this id!! so we reutrn true
            {
                sqlite3_finalize(stmt);
                return true;
            }
        }
    }
    sqlite3_finalize(stmt);
    return false;
}
int SqliteDatabase::doesPasswordMatch(std::string name, std::string pass2)
{
    sqlite3_stmt* stmt = nullptr;
    std::string sqlCmd = "SELECT PASS FROM USERS WHERE NAME = '" + name + "';";

    if (sqlite3_prepare_v2(_db, sqlCmd.c_str(), -1, &stmt, nullptr) == SQLITE_OK)
    {
        if (sqlite3_step(stmt) == SQLITE_ROW)
        {
            const unsigned char* dbPass = sqlite3_column_text(stmt, 0);
            if (dbPass)
            {
                std::string passwordInDb((const char*)dbPass);
                bool match = (passwordInDb == pass2);
                sqlite3_finalize(stmt);
                return match; 
            }
        }
    }
    sqlite3_finalize(stmt);
    return false;
}
int SqliteDatabase::addNewUser(std::string name, std::string pass, std::string email)
{
    char* errMes = nullptr;

    std::string sql = "INSERT INTO USERS (NAME, PASS, EMAIL) VALUES ('" +
        name + "', '" + pass + "', '" + email + "');";

    int res = sqlite3_exec(_db, sql.c_str(), nullptr, nullptr, &errMes);

    if (res != SQLITE_OK)
    {
        if (errMes != nullptr)
        {
            std::cout << "SQL Error in addNewUser: " << errMes << std::endl;
            sqlite3_free(errMes);
        }
        return res;
    }

    return SQLITE_OK;
}