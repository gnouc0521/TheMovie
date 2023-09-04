import {Store,Module,ActionContext} from 'vuex'
import ListModule from './list-module'
import ListState from './list-state'
import Movie from '../entities/movie'
import Ajax from '../../lib/ajax'
import PageResult from '@/store/entities/page-result';

interface MovieState extends ListState<Movie>{
    editMovie:Movie;
    permissions:Array<string>
}
class MovieModule extends ListModule<MovieState,any,Movie>{
    state={
        totalCount:0,
        currentPage:1,
        pageSize:10,
        list: new Array<Movie>(),
        loading:false,
        editMovie:new Movie(),
        permissions:new Array<string>()
    }
    actions={
        async getAll(context:ActionContext<MovieState,any>,payload:any){
            context.state.loading=true;
            let reponse=await Ajax.get('/api/services/app/Movie/GetAll',{params:payload.data});
            context.state.loading=false;
            let page=reponse.data.result as PageResult<Movie>;
            context.state.totalCount=page.totalCount;
            context.state.list=page.items;
        },
        async create(context:ActionContext<MovieState,any>,payload:any){
            await Ajax.post('/api/services/app/Movie/Create',payload.data);
        },
        async update(context:ActionContext<MovieState,any>,payload:any){
            await Ajax.put('/api/services/app/Movie/Update',payload.data);
        },
        async delete(context:ActionContext<MovieState,any>,payload:any){
            await Ajax.delete('/api/services/app/Movie/Delete?Id='+payload.data.id);
        },
        async get(context:ActionContext<MovieState,any>,payload:any){
            let reponse=await Ajax.get('/api/services/app/Moive/Get?Id='+payload.id);
            return reponse.data.result as Movie;
        },
    };
    mutations={
        setCurrentPage(state:MovieState,page:number){
            state.currentPage=page;
        },
        setPageSize(state:MovieState,pagesize:number){
            state.pageSize=pagesize;
        },
        edit(state:MovieState,movie:Movie){
            state.editMovie=movie;
        }
    }
}
const roleModule=new MovieModule();
export default roleModule;