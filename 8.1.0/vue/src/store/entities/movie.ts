import Entity from './entity'

export default class Movie extends Entity<number>{
    title:string;
    description:string;
    pathMovie : string;
    url: string; 
}