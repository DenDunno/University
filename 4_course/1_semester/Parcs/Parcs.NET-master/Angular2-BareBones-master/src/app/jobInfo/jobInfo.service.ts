import {Injectable} from 'angular2/core';
import {Http, Response, Headers} from 'angular2/http';
import {JobInfo}           from './jobInfo';
import {Observable}     from 'rxjs/Observable';

@Injectable()
export class JobInfoService {
        
    constructor (private http: Http) {}
    
    private _jobInfoUrl = 'http://localhost:1236/api/job';  // extract to CONSTANTS
    
    public get(): Observable<JobInfo[]> {
        return this.http.get(this._jobInfoUrl)
                .map(this.extractData);
    }
    
    public cancelJob(jobNumber: number) {
        var headers = new Headers();
        headers.append('Content-Type', 'application/json');
        return this.http.post(this._jobInfoUrl + '/cancel', JSON.stringify({number: jobNumber}), {headers: headers});
    }
    
    private extractData(res: Response) {
        if (res.status < 200 || res.status >= 300) {
            throw new Error('Bad response status: ' + res.status);
        }
        
        let body = res.json();
        return body;
    }
    
    private handleError (error: any) {
        let errMsg = error.message || 'Server error';
        console.error(errMsg); // log to console instead
        return Observable.throw(errMsg);
    }
}