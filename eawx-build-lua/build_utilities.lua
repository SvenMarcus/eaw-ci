---@param source string
---@param target string
---@param name_suffix string
function link_common_mod_data(job, source, target)
    local source_separator = ''
    if source:len() > 0 then
        source_separator = '/'
    end
    source = source .. source_separator

    local target_separator = ''
    if target:len() > 0 then
        target_separator = '/'
    end
    target = target .. target_separator

    job:add_task(link(source .. 'Data/XML', target .. 'Data/XML'):overwrite(true))
    job:add_task(link(source .. 'Data/Art', target .. 'Data/Art'):overwrite(true))
    job:add_task(link(source .. 'Data/Scripts', target .. 'Data/Scripts'):overwrite(true))
end