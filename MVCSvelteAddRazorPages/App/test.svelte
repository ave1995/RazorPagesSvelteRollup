<script lang="ts">
    import { getValue } from "$shared/init";
    let hello = getValue<string>("Hello");
    let dataToSend = { Username: "", Password: "" };

    async function sendData() {
        try {
            const tokenInput = document.querySelector(
                'input[name="__RequestVerificationToken"]'
            ) as HTMLInputElement;

            const tokenValue = tokenInput ? tokenInput.value.trim() : null;

            const headers: Record<string, string> = {
                Accept: "application/json",
                "Content-Type": "application/json"
            };

            if (tokenValue) {
                headers["RequestVerificationToken"] = tokenValue;
            }

            // if (XsrfValue) {
            //     headers["RequestVerificationToken"] = XsrfValue;
            // }
            const response = await fetch("/test", {
                method: "POST",
                headers: headers,
                body: JSON.stringify(dataToSend)
            });

            if (response.ok) {
                // Data sent successfully
                const responseData = await response.json();
                console.log("Response from Razor page:", responseData);
            } else {
                // Handle error
                console.error(
                    "Error sending data to Razor page:",
                    response.status,
                    response.statusText
                );
            }
        } catch (error) {
            console.error("An error occurred:", error);
        }
    }
</script>

<h2 class="text-center text-primary">{hello}</h2>
<div>
    <h2>Login</h2>
    <form on:submit|preventDefault={sendData} method="post">
        <div class="form-group">
            <label for="username">Username:</label>
            <input type="text" required bind:value={dataToSend.Username}/>
        </div>
        <div class="form-group">
            <label for="password">Password:</label>
            <input type="password" required bind:value={dataToSend.Password}/>
        </div>
        <div class="form-group">
            <input type="submit" value="Login" />
        </div>
    </form>
</div>
