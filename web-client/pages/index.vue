<template>
 <div>

  <v-file-input accept="video/*" @change="handleFile"></v-file-input>

  <form action="">
    <input name="">
  </form>

  <div v-if="tricks">
      <p v-for="t in tricks">
        {{t.name}}
      </p>
  </div>

  <div>
            <v-text-field label="Tricking Name" v-model="trickName"></v-text-field>
            <v-btn @click="saveTrick">Save Trick</v-btn>
  </div>

          {{message}}
          <v-btn @click="reset">Reset Message</v-btn>
          <v-btn @click="resetTricks">Reset Tricks</v-btn>
 </div>  
</template>

<script>
import {mapState,mapActions,mapMutations} from 'vuex';

export default {
  data:()=>({
    trickName : ""
  }),
  computed: {
  ...mapState({
    message:state => state.message
  }),
  ...mapState('tricks',{
    tricks:state=>state.tricks
  })
},
  methods:{
    ...mapMutations([
      'reset'
    ]),
    ...mapMutations('tricks',{
      resetTricks: 'reset'
    }),
    ...mapActions('tricks',['createTrick']),
     async saveTrick(){
       await this.createTrick({trick: {name:this.trickName}});
       this.trickName ="";
     },
     async handleFile(file)
     {
       if (!file) return;

       const form = new FormData(); 

       form.append();

        const result = await  Axios.post("http://localhost:5000/api/videos");
        console.log(result);
     }
  }
}
</script>
