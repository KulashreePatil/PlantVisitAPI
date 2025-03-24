import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root',
})
export class PlantService {
    getPlants() {
        throw new Error('Method not implemented.');
    }

    private baseUrl = 'https://localhost:7000/api/Plant/GetFacilityList';

    constructor(private http: HttpClient) {}

    getData(searchTerm?: string): Observable<any> {
        const url = searchTerm ? `${this.baseUrl}?searchTerm=${searchTerm}` : this.baseUrl;
        return this.http.get<any>(url);
    }

    postData(data: any): Observable<any> {
        return this.http.post(this.baseUrl, data);
    }
}
