export const Constant={
    LOCALVARIABLENAME:{
       TOKEN: 'TOKEN',
       REFRESH_TOKEN:'REFRESH_TOKEN'
   }
}
export const HandleLocalStore={
    writeToken:(token)=>{
        localStorage.setItem(Constant.LOCALVARIABLENAME.TOKEN,token);
    },

    writeRefreshToken(refreshToken){
        localStorage.setItem(Constant.LOCALVARIABLENAME.REFRESH_TOKEN,refreshToken);
    },
    clearToken(){
        localStorage.removeItem(Constant.LOCALVARIABLENAME.TOKEN);
    },
    clearRefreshToken(){
        localStorage.removeItem(Constant.LOCALVARIABLENAME.REFRESH_TOKEN)
    },
    getToken(){
        return localStorage.getItem(Constant.LOCALVARIABLENAME.TOKEN)
    },
    getRefreshToken(){
        return localStorage.getItem(Constant.LOCALVARIABLENAME.REFRESH_TOKEN)
    }
}