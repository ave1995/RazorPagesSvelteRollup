<script lang="ts">
    import {getValue} from "$shared/init"
    let hello = getValue<string>("Hello");
</script>


<h2 class="text-center text-primary">{hello}</h2>
