import { setTitle, setFetchConfig, setHeaderLinks, setCommonUrls } from "$lib/config";
import urls from "$shared/urls";
//import { theme } from "$lib/theme";
export const getValue = (id) => {
    const e = document.querySelector(`input#${id}[type=hidden]`);
    if (!e) {
        return "";
    }
    const value = e.value;
    e.remove();
    return value;
};
/* eslint-disable-next-line @typescript-eslint/no-explicit-any */
const getValueFromJson = (id) => JSON.parse(getValue(id));
export default function init(pageName) {
    var _a, _b;
    console.log(`init ${pageName}`);
    setTitle(getValue("title"));
    //setKeys(getValue<string>("error-key") ?? "", getValue<string>("theme-key") ?? "");
    setFetchConfig((_a = getValue("cache-version")) !== null && _a !== void 0 ? _a : "", (_b = getValue("url-prefix")) !== null && _b !== void 0 ? _b : "");
    //const user = getValueFromJson<IUser>("user");
    //setUser(user);
    setHeaderLinks([
        { text: "Settings", url: "/settings" },
        { text: "Logout", url: urls.logoutUrl }
    ], [
        { text: "Login", url: urls.loginUrl },
        { text: "Register", url: urls.loginUrl }
    ]);
    setCommonUrls(urls.errorUrl, urls.notFoundUrl);
    //let themeValue: string = "";
    //theme.subscribe((value) => (themeValue = value));
    return {
        user: "",
        theme: ""
    };
}
//# sourceMappingURL=init.js.map