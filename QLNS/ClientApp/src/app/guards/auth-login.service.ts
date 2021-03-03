import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, CanLoad, Route, Router, RouterStateSnapshot, UrlSegment, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthLoginService implements CanActivate,CanLoad {

  constructor(private _authService: AuthService,private _route: Router) { }
  canLoad(route: Route, segments: UrlSegment[]){
    return this._authService.loginIn();
  }
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
   if( this._authService.loginIn()){
     return true;
   }
   else{
   this._route.navigate([""])
     return false;

   }
  }
}
