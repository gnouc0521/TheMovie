<template>
    <div>
        <Modal
         :title="('CreateNewMovie')"
         :value="value"
         @on-ok="save"
         @on-visible-change="visibleChange"
        >
            <Form ref="movieForm"  label-position="top" :rules="movieRule" :model="movie">
                <Tabs value="detail">
                    <TabPane :label="('Movie')" name="detail">
                        <FormItem :label="('Title')" prop="name">
                            <Input v-model="movie.title" :maxlength="32" :minlength="2"></Input>
                        </FormItem>
                        <FormItem :label="('Description')" prop="description">
                            <Input v-model="movie.description" :maxlength="1024"></Input>
                        </FormItem>
                      </TabPane>
                </Tabs>
            </Form>
            <div slot="footer">
                <Button @click="cancel">{{('Cancel')}}</Button>
                <Button @click="save" type="primary">{{('OK')}}</Button>
            </div>
        </Modal>
    </div>
</template>
<script lang="ts">
    import { Component, Vue,Inject, Prop,Watch } from 'vue-property-decorator';
    import Util from '../../lib/util'
    import AbpBase from '../../lib/abpbase'
    //import Role from '@/store/entities/role';
    import Movie from '@/store/entities/movie';
    @Component
    export default class CreateRole extends AbpBase{
        @Prop({type:Boolean,default:false}) value:boolean;
        movie: Movie = new Movie();
      //  role:Role=new Role();
        get permissions(){
            return this.$store.state.role.permissions
        }
        save(){
            (this.$refs.movieForm as any).validate(async (valid:boolean)=>{
                if(valid){
                    await this.$store.dispatch({
                        type:'movie/create',
                        data:this.movie
                    });
                   // (this.$refs.roleForm as any).resetFields();
                    this.$emit('save-success');
                    this.$emit('input',false);
                }
            })
        }
        cancel(){
            (this.$refs.roleForm as any).resetFields();
            this.$emit('input',false);
        }
        visibleChange(value:boolean){
            if(!value){
                this.$emit('input',value);
            }
        }
        movieRule={
           // name:[{required: true,message:this.L('FieldIsRequired',undefined,this.L('RoleName')),trigger: 'blur'}],
            displayName:[{required:true,message:this.L('FieldIsRequired',undefined,this.L('DisplayName')),trigger: 'blur'}]
        }
    }
</script>

